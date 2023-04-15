import { SpeakerDTO } from "./speakerDto";

export interface EventsDTO {
  id: number;
  title: string;
  description: number;
  eventDate: Date;
  type: number;
  venu: string;
  website: string;
  linkForDetails: string;
  speakerId: number;
  speaker: SpeakerDTO;
  organizationId: number;
}
