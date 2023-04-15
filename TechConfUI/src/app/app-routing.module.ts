import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './feature/dashboard/dashboard.component';
import { AuthGuardService } from './shared/guard/auth.guard.service';
import { SpeakersComponent } from './feature/speakers/speakers.component';
import { EventsComponent } from './feature/events/events.component';
import { SpeakerSessionsComponent } from './feature/speakersessions/speakersessions.component';
import { LoginComponent } from './feature/login/login.component';
import { NotfoundComponent as NotFoundComponent } from './feature/notfound/notfound.component';
import { SpeakerUpsertComponent } from './feature/speakers/upsert/upsert.component';
import { EventUpsertComponent } from './feature/events/upsert/upsert.component';
import { SpeakerSessionsUpsertComponent } from './feature/speakersessions/upsert/upsert.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'speakers',
    component: SpeakersComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'speaker/upsert',
    canActivate: [AuthGuardService],
    children: [
      { path: '', component: SpeakerUpsertComponent },
      { path: ':id', component: SpeakerUpsertComponent },
    ],
  },
  { path: 'events', component: EventsComponent, canActivate: [AuthGuardService] },
  { path: 'events/:speakerid', component: EventsComponent, canActivate: [AuthGuardService] },
  {
    path: 'event/upsert',
    canActivate: [AuthGuardService],
    children: [
      { path: '', component: EventUpsertComponent },
      { path: ':id', component: EventUpsertComponent },
    ],
  },
  {
    path: 'speakersessions/:eventId',
    component: SpeakerSessionsComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'speakersessions/:eventId/upsert',
    canActivate: [AuthGuardService],
    children: [
      { path: '', component: SpeakerSessionsUpsertComponent },
      { path: ':id', component: SpeakerSessionsUpsertComponent },
    ],
  },
  { path: 'login', component: LoginComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
