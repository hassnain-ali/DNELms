import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountrieslistComponent } from './countrieslist.component';

describe('CountrieslistComponent', () => {
  let component: CountrieslistComponent;
  let fixture: ComponentFixture<CountrieslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountrieslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountrieslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
