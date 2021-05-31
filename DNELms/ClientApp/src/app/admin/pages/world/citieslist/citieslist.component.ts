import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge, Observable, of as observableOf } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-citieslist',
  templateUrl: './citieslist.component.html',
  styleUrls: ['./citieslist.component.css']
})
export class CitieslistComponent implements AfterViewInit {
  displayedColumns: string[] = ['CityName', 'StateName', 'CountryName', 'Logitude', 'Latitude'];
  exampleDatabase: CitiesHttpDatabase | null;
  data: any[] = [];

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private _httpClient: HttpClient) { }

  ngAfterViewInit() {
    this.exampleDatabase = new CitiesHttpDatabase(this._httpClient);

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.exampleDatabase!.getRepoIssues(
            this.sort.active, this.sort.direction, this.paginator.pageIndex);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.total_count;

          return data.items;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          // Catch if the GitHub API has reached its rate limit. Return empty data.
          this.isRateLimitReached = true;
          return observableOf([]);
        })
      ).subscribe(data => this.data = data);
  }
}

export class CitiesHttpDatabase {
  constructor(private _httpClient: HttpClient) { }

  getRepoIssues(sort: string, order: string, page: number): Observable<GithubApi> {
    const href = 'api/Cities';
    const requestUrl =
      `${href}?q=&sort=${sort}&order=${order}&page=${page + 1}`;

    return this._httpClient.get<GithubApi>(requestUrl);
  }
}
export interface GithubApi {
  items: any[];
  total_count: number;
}