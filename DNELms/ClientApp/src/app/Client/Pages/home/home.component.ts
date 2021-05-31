import { AfterViewInit, Component, OnInit } from '@angular/core';
import * as jq from 'jquery';
declare var $: any;
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {
  slideConfig: any = {}
  constructor() {
    this.slideConfig = {
      dots: false,
      infinite: false,
      speed: 300,
      slidesToShow: 6,
      slidesToScroll: 6,
      swipe: false,
      touchMove: false,
      responsive: [
        {
          breakpoint: 1300,
          settings: {
            slidesToShow: 5,
            slidesToScroll: 5,
          }
        },
        {
          breakpoint: 1100,
          settings: {
            slidesToShow: 4,
            slidesToScroll: 4
          }
        },
        {
          breakpoint: 840,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 3
          }
        },
        {
          breakpoint: 620,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 2
          }
        },
        {
          breakpoint: 480,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1
          }
        }
      ]
    };
  }
  ngAfterViewInit(): void {
    init();
  }



}
function init() {

  $('.has-popover').webuiPopover({
    trigger: 'hover',
    placement: 'horizontal',
    delay: {
      show: 300,
      hide: null
    },
    width: 335
  });
}