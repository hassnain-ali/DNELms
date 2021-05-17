import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerlistComponent } from './bannerlist.component';

describe('BannerlistComponent', () => {
  let component: BannerlistComponent;
  let fixture: ComponentFixture<BannerlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BannerlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BannerlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
