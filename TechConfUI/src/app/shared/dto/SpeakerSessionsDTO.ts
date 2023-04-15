export interface SpeakerSessionsDTO{
  id: number;
  name : string;
  eventId : number;
  speakerId : number;
  organizationId : number;
  startTime : Date;
  endTime: Date
}
