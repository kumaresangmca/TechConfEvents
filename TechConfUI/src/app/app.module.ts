import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SpeakersComponent } from './feature/speakers/speakers.component';
import { SpeakerSessionsComponent } from './feature/speakersessions/speakersessions.component';
import { EventsComponent } from './feature/events/events.component';
import { LoginComponent } from './feature/login/login.component';
import { DashboardComponent } from './feature/dashboard/dashboard.component';
import { NotfoundComponent } from './feature/notfound/notfound.component';
import { SpeakerUpsertComponent } from './feature/speakers/upsert/upsert.component';
import { AuthInterceptor } from './shared/interceptor/auth.interceptor';
import { EventUpsertComponent } from './feature/events/upsert/upsert.component';
import { SpeakerSessionsUpsertComponent } from './feature/speakersessions/upsert/upsert.component';

@NgModule({
  declarations: [
    AppComponent,
    SpeakersComponent,
    EventsComponent,
    LoginComponent,
    DashboardComponent,
    NotfoundComponent,
    EventUpsertComponent,
    SpeakerUpsertComponent,
    SpeakerSessionsComponent,
    SpeakerSessionsUpsertComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [{
    provide : HTTP_INTERCEPTORS,
    useClass : AuthInterceptor,
    multi : true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
