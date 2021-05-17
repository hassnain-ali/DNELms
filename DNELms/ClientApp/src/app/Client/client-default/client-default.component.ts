import { Component, HostListener, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core/common-behaviors/color';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-client-default',
  templateUrl: './client-default.component.html',
  styleUrls: ['./client-default.component.css']
})
export class ClientDefaultComponent implements OnInit {
  IsLoading: boolean = true;
  progresValue: number = 0;
  color: ThemePalette = 'primary';
  constructor(private _router: Router) {
    this._router.events.subscribe((event: any) => {
      this.navigationInterceptor(event);
    });
  }
  @HostListener("window:scroll", [])
  onWindowScroll() {
    var element: any = document.documentElement,
      body: any = document.body,
      scrollTop = 'scrollTop',
      scrollHeight = 'scrollHeight';
    this.progresValue =
      (element[scrollTop] || body[scrollTop]) /
      ((element[scrollHeight] || body[scrollHeight]) - element.clientHeight) * 100;
  }
  ngOnInit(): void {
  }
  private navigationInterceptor(event: Event): void {
    if (event instanceof NavigationStart) {
      this.IsLoading = true;
    }
    if (event instanceof NavigationEnd) {
      setTimeout(() => {
        this.IsLoading = false;
      }, 2000);
    }
    if (event instanceof NavigationCancel) {
      this.IsLoading = false;
    }
    if (event instanceof NavigationError) {
      this.IsLoading = false;
    }
  }
}
