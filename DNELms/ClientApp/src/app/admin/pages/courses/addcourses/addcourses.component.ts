import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDatepicker, MatDateRangePicker } from '@angular/material/datepicker';

@Component({
  selector: 'app-addcourses',
  templateUrl: './addcourses.component.html',
  styleUrls: ['./addcourses.component.css']
})
export class AddcoursesComponent implements OnInit {

  constructor() { }
  TodayDate = new Date();
  ngOnInit(): void {

  }

}
