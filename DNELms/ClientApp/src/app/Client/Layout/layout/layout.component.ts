import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { AfterViewInit, Component, Inject, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService, IUser } from '../../../../api-authorization/authorize.service';

import * as $ from 'jquery';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements AfterViewInit {
  public isAuthenticated: Observable<boolean> = new Observable<boolean>();
  public userName: Observable<string> = new Observable<string>();

  constructor(private authorizeService: AuthorizeService, private _repository: AuthorizeService,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  ngOnInit(): void {

    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name || ""));

  }
  ngAfterViewInit() {
    // $('.mobile-nav-trigger').on('click', function (event) {
    //   if (!checkWindowWidth(768)) event.preventDefault();
    //   $('.mobile-main-nav').addClass('nav-is-visible');
    //   toggleSearch('close');
    //   $('.mobile-overlay').addClass('is-visible');
    // });




    //open search form
    $('.mobile-search-trigger').on('click', (event: JQuery.Event) => {
      event.preventDefault();
      toggleSearch('');
    });

    //mobile - open lateral menu clicking on the menu icon
    $('.mobile-nav-trigger').on('click', function (event) {
      if (!checkWindowWidth(768)) event.preventDefault();
      $('.mobile-main-nav').addClass('nav-is-visible');
      toggleSearch('close');
      $('.mobile-overlay').addClass('is-visible');
    });

    //submenu items - go back link
    $('.go-back').on('click', function (event) {
      event.preventDefault();
      $(this).parent('ul').addClass('is-hidden').parent('.has-children').parent('ul').removeClass('moves-out');
    });
    $('.go-back-menu').on('click', function (event) {
      event.preventDefault();
      $(this).parent('ul').addClass('is-hidden').parent('.has-children').parent('ul').removeClass('moves-out').addClass('is-hidden').parent('.has-children').parent('ul').removeClass('moves-out');
    });

    //open submenu
    $('.has-children').children('a').on('click', function (event) {
      event.preventDefault();
      var selected = $(this);
      if (selected.next('ul').hasClass('is-hidden')) {
        //desktop version only
        selected.addClass('selected').next('ul').removeClass('is-hidden').end().parent('.has-children').parent('ul').addClass('moves-out');
        selected.parent('.has-children').siblings('.has-children').children('ul').addClass('is-hidden').end().children('a').removeClass('selected');
        $('.mobile-overlay').addClass('is-visible');
      } else {
        selected.removeClass('selected').next('ul').addClass('is-hidden').end().parent('.has-children').parent('ul').removeClass('moves-out');
        $('.mobile-overlay').removeClass('is-visible');
      }
      toggleSearch('close');
    });

    //close lateral menu on mobile
    $('.mobile-overlay').on('click', function () {
      closeNav();
      $('.mobile-overlay').removeClass('is-visible');
    });


    //prevent default clicking on direct children of .mobile-main-nav
    $('.mobile-main-nav').children('.has-children').children('a').on('click', function (event) {
      event.preventDefault();
    });
  }


}

function toggleSearch(type: string) {
  if (type == "close") {
    //close serach
    $('.mobile-search').removeClass('is-visible');
    $('.mobile-search-trigger').removeClass('search-is-visible');
  } else {
    //toggle search visibility
    $('.mobile-search').toggleClass('is-visible');
    $('.mobile-search-trigger').toggleClass('search-is-visible');
  }
}
function closeNav() {
  // $('.mobile-nav-trigger').removeClass('nav-is-visible');
  $('.mobile-main-nav').removeClass('nav-is-visible');
  setTimeout(function () { $('.has-children ul').addClass('is-hidden'); }, 600);
  $('.has-children a').removeClass('selected');
  $('.moves-out').removeClass('moves-out');
}

function checkWindowWidth(arg0: number) {
  //check window width (scrollbar included)
  let e: any = window;
  let a = 'inner';
  if (!('innerWidth' in window)) {
    a = 'client';
    e = document.documentElement || document.body;
  }
  if (e[a + 'Width'] >= arg0) {
    return true;
  } else {
    return false;
  }
}

