import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiUrl } from 'src/app/shared/constant/api.constant';
import { EventsDTO } from 'src/app/shared/dto/eventsDTO';
import { ResultDTO } from 'src/app/shared/dto/resultDto';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  events: Array<EventsDTO> = [];
  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.loadListData();
  }
  loadListData() {
    this.http.get(ApiUrl.events).subscribe(
      (data: ResultDTO) => {
        console.log('loadEvents: success:', data);
        if (data.results) {
          let items = data.results as Array<EventsDTO>;

          this.events = [...items];
        }
      },
      (error: HttpErrorResponse) => {
        console.log('loadEvents: error:', error);
      }
    );
  }
  public onDelete(event: EventsDTO) {
    const action = confirm('Are you sure want delete the selected record?');
    if (action) {
      this.http
        .delete(ApiUrl.eventsById.replace('{id}', event.id.toString()))
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
  public onDownload(event: EventsDTO) {
    this.http
      .get(ApiUrl.eventsDownloadById.replace('{id}', event.id.toString()),{responseType : "arraybuffer"})
      .subscribe(
        (data: any) => {
          console.log('onDownload: success:', data);
          let file = new File([data], event.title + '.csv', {
            type: 'text/csv:charset=UTF-8',
          });
          let url = window.URL.createObjectURL(file);
          var element = document.createElement('a');
          element.setAttribute('href', url);
          element.setAttribute('download', event.title+".csv");
          element.style.display = 'none';
          document.body.appendChild(element);
          element.click();
          document.body.removeChild(element);
        },
        (error: HttpErrorResponse) => {
          console.log('onDownload: error:', error);
        }
      );
  }
  manageSession(event: EventsDTO){
    sessionStorage.setItem("selectedEvent", JSON.stringify(event));
    this.router.navigate(["speakersessions", event.id]);

  }
}
