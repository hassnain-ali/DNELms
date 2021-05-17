import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent implements OnInit {

  public isUserAuthenticated: boolean = false;
  constructor(private _authService: AuthorizeService) {
    // this._authService.loginChanged
    //   .subscribe(res => {
    //     this.isUserAuthenticated = res;
    //   })
  }
  ngOnInit(): void {
    this._authService.isAuthenticated()
      .subscribe(isAuth => {
        this.isUserAuthenticated = isAuth;
      })
  }
  public login = () => {
    //this._authService.();
  }
  public logout = () => {
    //this._authService.signOut();
  }

}
