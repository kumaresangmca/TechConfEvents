import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApiUrl } from 'src/app/shared/constant/api.constant';
import { ResultDTO } from 'src/app/shared/dto/resultDto';
import { SpeakerDTO } from 'src/app/shared/dto/speakerDto';

@Component({
  selector: 'app-speakers',
  templateUrl: './speakers.component.html',
  styleUrls: ['./speakers.component.scss']
})
export class SpeakersComponent implements OnInit {
  speakers: Array<SpeakerDTO> = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.loadListData();
  }
  loadListData(){
    this.http.get(ApiUrl.speakers).subscribe(
      (data: ResultDTO)=>{
        console.log("loadSpeakers: success:", data);
        if(data.results){
          let items = data.results as Array<SpeakerDTO>;

          this.speakers = [...items];
        }
      },
      (error : HttpErrorResponse) =>{
        console.log("loadSpeakers: error:", error);
      }
    );
  }
  public onDelete(speaker: SpeakerDTO){
      const action = confirm("Are you sure want delete the selected record?");
      if(action){
        this.http.delete(ApiUrl.speakerById.replace("{id}", speaker.id.toString())).subscribe(
          (data: ResultDTO)=>{
            console.log("onDelete: success:", data);
            if(data.results){
              let isDeleted = data.results as boolean;
              if(isDeleted){
                this.loadListData();
              }

            }
          },
          (error : HttpErrorResponse) =>{
            console.log("onDelete: error:", error);
          }
        );
      }
  }
}
