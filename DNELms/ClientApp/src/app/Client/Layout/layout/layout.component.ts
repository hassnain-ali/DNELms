import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService, IUser } from '../../../../api-authorization/authorize.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  public isAuthenticated: Observable<boolean> = new Observable<boolean>();
  public userName: Observable<string> = new Observable<string>();

  constructor(private authorizeService: AuthorizeService, private _repository: AuthorizeService,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name || ""));
    this.getClaims();
  }
  public getClaims = () => {
    //Home/Privacy
    this.authorizeService.getAccessToken().subscribe(token => {
      var header = new Headers();
      header.set('Authorization', `Bearer ${token}`);
      //fetch(this.baseUrl + "/Home/Privacy").then(s => {
      //  console.log(s);
      //});
      fetch(this.baseUrl + "/Home/Privacyauth", { headers: header }).then(s => {
        console.log(s);
      });
    });
  }
}
