import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcoursetypesComponent } from './addcoursetypes.component';

describe('AddcoursetypesComponent', () => {
  let component: AddcoursetypesComponent;
  let fixture: ComponentFixture<AddcoursetypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddcoursetypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddcoursetypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
