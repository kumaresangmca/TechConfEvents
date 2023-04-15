import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/service/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({});
  isInvalidCode: boolean = false;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      code: ['', Validators.required],
    });
  }
  submitForm() {
    this.isInvalidCode = false;
    this.authService
      .Login(this.form.value['code'])
      .subscribe((data: boolean) => {
        if (data) {
          this.router.navigate(['dashboard']);
        } else {
          this.isInvalidCode = true;
        }
      });
  }
  ngOnDestroy(): void {}
}
