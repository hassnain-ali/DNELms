import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable } from 'rxjs';
import { merge } from 'rxjs';
import { of as observableOf } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { startWith } from 'rxjs/operators';
import { switchMap } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { EntityService } from './EntityService';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-categorieslist',
  templateUrl: './categorieslist.component.html',
  styleUrls: ['./categorieslist.component.css']
})
export class CategorieslistComponent implements AfterViewInit {
  entities: any[];
  entitiesDataSource: MatTableDataSource<any> = new MatTableDataSource();
  displayedColumns = ['Name', 'ParentName', 'IsActive', "Actions"];
  entityService: EntityService;
  resultsLength = 0;
  isLoadingResults = false;
  isRateLimitReached = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public constructor(http: HttpClient, private cdr: ChangeDetectorRef) {
    this.entityService = new EntityService(http);
  }

  public ngAfterViewInit() {

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.entityService.fetchLatest(
            this.sort.active, this.sort.direction, this.paginator.pageIndex)
            .pipe(catchError(() => observableOf(null)));
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = data === null;

          if (data === null) {
            return [];
          }

          // Only refresh the result length if there is new data. In case of rate
          // limit errors, we do not want to reset the paginator to zero, as that
          // would prevent users from re-triggering requests.
          this.resultsLength = data.Data.total_count;
          return data.Data.items.$values;
        })
      ).subscribe(data => this.entitiesDataSource.data = data);
    this.cdr.detectChanges();
    // this.isLoadingResults = true;
    // this.entityService.fetchLatest(this.sort.active, this.sort.direction,
    //   this.paginator.pageIndex + 1, this.paginator.pageSize).subscribe((res: any) => {
    //     console.log(res);
    //     this.isLoadingResults = false;
    //     this.resultsLength = res.Data.total_count;
    //     this.entitiesDataSource.data = res.Data.items.$values;
    //   });
  }

}
