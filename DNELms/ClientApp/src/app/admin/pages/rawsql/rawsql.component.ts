import { DataSource } from '@angular/cdk/collections';
import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { error } from 'jquery';
import { Convert } from 'src/app/Common/Convert';

@Component({
  selector: 'app-rawsql',
  templateUrl: './rawsql.component.html',
  styleUrls: ['./rawsql.component.css']
})
export class RawsqlComponent implements OnInit, AfterViewInit {
  constructor(private http: HttpClient) {
    this.IsTable = false;
    this.IsError = false;
    this.IsSuccess = true;
    this.Table = [];
    this.Result = 'Execute any query first';
  }
  baseUrl = window.location.origin + '/api/';
  QueryGroup: FormGroup = new FormGroup({
    Query: new FormControl('', Validators.required)
  });
  IsBusy: boolean = true;
  @ViewChild(MatSort) sort: MatSort;
  IsTable: boolean;
  IsError: boolean;
  IsSuccess: boolean;
  Table: any[];
  Result: any;
  ExFirst: boolean = false;
  Columns: string[];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  ngOnInit(): void {
    this.IsBusy = false;
  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }
  Execute() {
    this.IsBusy = true;
    let values = this.QueryGroup.value;
    let valss = {
      Query: values.Query
    };
    this.http.post(this.baseUrl + 'RawSql', valss).subscribe((s: any) => {

      this.IsBusy = false;
      console.log(s);
      if (s.RecordsAffected == -1) {
        this.IsSuccess = true;
        this.IsError = false;
        this.IsTable = true;
        this.Columns = s.Columns.$values;
        this.Table = Object.values(JSON.parse(s.Result));
        this.dataSource.data = this.Table;
      }
      else if (s.RecordsAffected == -2) {
        this.IsSuccess = false;
        this.IsError = true;
        this.IsTable = false;
        this.Result = s.Error;
      }
      else {
        this.IsSuccess = true;
        this.IsError = false;
        this.IsTable = false;
        this.Result = `${s.RecordsAffected} Rows affacted.`;
      }
      this.ExFirst = true;
      setTimeout(() => {
        this.dataSource.sort = this.sort;
      }, 700);
    }, error => {
      this.IsBusy = false;
      console.log(error);
    });
  }
}
