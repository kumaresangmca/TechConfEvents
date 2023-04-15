const ApiBaseUrl = "http://localhost:1784/api/";

export const ApiUrl = {
   organizationsByCode : `${ApiBaseUrl}organizations/{code}`,
   speakers : `${ApiBaseUrl}speakers`,
   speakerById : `${ApiBaseUrl}speakers/{id}`,
   events : `${ApiBaseUrl}events`,
   eventsById : `${ApiBaseUrl}events/{id}`,
   eventsDownloadById : `${ApiBaseUrl}events/download/{id}`,
   speakerSessions : `${ApiBaseUrl}speakersessions`,
   speakerSessionsByEventId : `${ApiBaseUrl}speakersessions/{eventId}`,
   speakerSessionsByEventAndSessionId : `${ApiBaseUrl}speakersessions/{eventId}/{id}`,
   speakerSessionsById : `${ApiBaseUrl}speakersessions/{id}`
};
