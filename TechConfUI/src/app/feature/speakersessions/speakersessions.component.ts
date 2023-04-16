import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiUrl } from 'src/app/shared/constant/api.constant';
import { SpeakerSessionsDTO } from 'src/app/shared/dto/SpeakerSessionsDTO';
import { EventsDTO } from 'src/app/shared/dto/eventsDTO';
import { ResultDTO } from 'src/app/shared/dto/resultDto';

@Component({
  selector: 'app-speakersessions',
  templateUrl: './speakersessions.component.html',
  styleUrls: ['./speakersessions.component.scss'],
})
export class SpeakerSessionsComponent implements OnInit {
  speakerSessions: Array<SpeakerSessionsDTO> = [];
  eventId: number = 0;
  event: EventsDTO = {} as EventsDTO;
  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe((param: any) => {
      this.eventId = +param.eventId;
    });
  }

  ngOnInit(): void {
    let selectedEvent = sessionStorage.getItem('selectedEvent') || '';
    this.event = JSON.parse(selectedEvent) as EventsDTO;
    this.loadListData();
  }
  loadListData() {
    this.http
      .get(
        ApiUrl.speakerSessionsByEventId.replace(
          '{eventId}',
          this.eventId.toString()
        )
      )
      .subscribe(
        (data: ResultDTO) => {
          console.log('loadListData: success:', data);
          if (data.results) {
            let items = data.results as Array<SpeakerSessionsDTO>;

            this.speakerSessions = [...items];
          }
        },
        (error: HttpErrorResponse) => {
          console.log('loadListData: error:', error);
        }
      );
  }
  public onDelete(speaker: SpeakerSessionsDTO) {
    const action = confirm('Are you sure want delete the selected record?');
    if (action) {
      this.http
        .delete(
          ApiUrl.speakerSessionsById.replace('{id}', speaker.id.toString())
        )
        .subscribe(
          (data: ResultDTO) => {
            console.log('onDelete: success:', data);
            if (data.results) {
              let isDeleted = data.results as boolean;
              if (isDeleted) {
                this.loadListData();
              }
            }
          },
          (error: HttpErrorResponse) => {
            console.log('onDelete: error:', error);
          }
        );
    }
  }
}
