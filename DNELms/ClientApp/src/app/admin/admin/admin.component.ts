import { ChangeDetectorRef, Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { PerfectScrollbarComponent, PerfectScrollbarConfigInterface, PerfectScrollbarDirective } from 'ngx-perfect-scrollbar';
import { ChangeDetectionStrategy } from '@angular/compiler/src/compiler_facade_interface';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {


  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  public type: string = 'component';

  public disabled: boolean = false;
  IsLoading: boolean = true;
  public config: PerfectScrollbarConfigInterface = {};

  // @ViewChild('perfectScroll') perfectScroll: PerfectScrollbarComponent;
  menuItems: any[] = [
    {
      label: 'Logout',
      icon: 'logout',
      showOnMobile: true,
      showOnTablet: true,
      showOnDesktop: true
    },
  ];
  constructor(private observer: BreakpointObserver, private cd: ChangeDetectorRef,
    private _router: Router) {
    this._router.events.subscribe((event: any) => {
      this.navigationInterceptor(event);
    });
  }

  ngOnInit(): void {
  }
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if (res.matches) {
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
      this.cd.detectChanges();
    });
  }
  private navigationInterceptor(event: Event): void {
    if (event instanceof NavigationStart) {
      this.IsLoading = true;
    }
    if (event instanceof NavigationEnd) {
      this.IsLoading = false;
    }
    if (event instanceof NavigationCancel) {
      this.IsLoading = false;
    }
    if (event instanceof NavigationError) {
      this.IsLoading = false;
    }
  }
}
