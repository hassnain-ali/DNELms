import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CitieslistComponent } from './citieslist.component';

describe('CitieslistComponent', () => {
  let component: CitieslistComponent;
  let fixture: ComponentFixture<CitieslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CitieslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CitieslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
