import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { MatInput } from '@angular/material/input';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge, Observable, of as observableOf } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { PagedEntityService } from 'src/app/admin/PagedEntityService';
import { CitiesService } from '../services/CitiesServices';

@Component({
  selector: 'app-citieslist',
  templateUrl: './citieslist.component.html',
  styleUrls: ['./citieslist.component.css']
})
export class CitieslistComponent implements AfterViewInit {
  displayedColumns: string[] = ['RowNo', 'CityName', 'StateName', 'CountryName', 'Longitude', 'Latitude', 'Actions'];
  entities: any[];
  entitiesDataSource: MatTableDataSource<any> = new MatTableDataSource();

  resultsLength = 0;
  isLoadingResults = false;
  isRateLimitReached = false;
  filterValue: string;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatInput) matInput: MatInput;

  public constructor(http: HttpClient, private cdr: ChangeDetectorRef, private entityService: PagedEntityService) {
  }

  ngAfterViewInit() {
    this.BindTable();
  }
  SearchCity(val: string) {
    this.BindTable();
  }

  BindTable() {

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page, this.matInput.stateChanges)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.entityService.fetchLatest(
            'Cities', this.sort.active, this.sort.direction, this.paginator.pageIndex, this.paginator.pageSize, this.filterValue)
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
  }

}
