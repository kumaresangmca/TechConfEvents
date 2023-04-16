import { Component } from '@angular/core';
import { AuthService } from './shared/service/auth/auth.service';
import { LoaderService } from './shared/service/loader/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  showLoader : boolean;
  constructor(public authService: AuthService, private loaderService: LoaderService){
    this.showLoader = false;
    this.loaderService.loader.subscribe((loader:boolean)=>{
      this.showLoader = loader;
    });
  }
}
