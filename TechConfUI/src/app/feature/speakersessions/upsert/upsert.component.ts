import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  ActivatedRoute,
  ActivatedRouteSnapshot,
  Router,
} from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ApiUrl } from 'src/app/shared/constant/api.constant';
import { ResultDTO } from 'src/app/shared/dto/resultDto';
import { SpeakerDTO } from 'src/app/shared/dto/speakerDto';

@Component({
  selector: 'app-sessions-upsert',
  templateUrl: './upsert.component.html',
  styleUrls: ['./upsert.component.scss'],
})
export class SpeakerSessionsUpsertComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({});
  isEdit: boolean = false;
  id: number = 0;
  eventId : number = 0;
  speakerId : number = 0;
  showForm: boolean = true;
  subscription: any;
  isFormSubmitting: boolean = false;
  speakers : Array<SpeakerDTO> = [];
  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {
    activatedRoute.params.subscribe((data: any) => {
      this.eventId = +data.eventId;
      if (+data.id > 0) {
        this.id = +data.id;
        this.isEdit = true;
        this.getFormData();
      }
    });
  }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      id: [0],
      eventId : this.eventId,
      name: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required]

    });
  }
  getFormData() {
    this.subscription = this.http
      .get(ApiUrl.speakerSessionsByEventAndSessionId.replace('{id}', this.id.toString()).replace('{eventId}', this.eventId.toString()))
      .subscribe(
        (data: ResultDTO) => {
          console.log('getFormData:success', data);
          if (data.results) {
            this.form.patchValue(data.results);
          }
        },
        (errorResponse: HttpErrorResponse) => {
          const errorData = errorResponse.error as ResultDTO;
          if (errorData && errorData.errorsMessages?.length) {
            this.showForm = false;
            alert(errorData.errorsMessages[0]);
            this.router.navigate(['events']);
          } else {
            alert('pls try again later');
          }
          console.log('getFormData:error', errorResponse);
        }
      );
  }
  onSubmit() {
    this.isFormSubmitting = true;
    let record = this.form.value;
    let observable: Observable<any>;
    if (this.isEdit) {
      observable = this.http.put(
        ApiUrl.speakerSessionsById.replace('{id}', this.id.toString()),
        record
      );
    } else {
      observable = this.http.post(ApiUrl.speakerSessions, record);
    }
    this.subscription = observable.subscribe(
      (data: ResultDTO) => {
        console.log('onsubmit:success:', data);
        this.router.navigate(["speakersessions", this.eventId]);
      },
      (error: HttpErrorResponse) => {
        this.isFormSubmitting = false;
        console.log('onsubmit:error:', error);
      }
    );
    console.log('formvalue', this.form.value);
  }

  ngOnDestroy(): void {
    let subs = this.subscription as Subscription;
    if (subs && !subs.closed) {
      subs.unsubscribe();
    }
  }
}
