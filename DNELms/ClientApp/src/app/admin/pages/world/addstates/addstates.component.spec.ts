import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddstatesComponent } from './addstates.component';

describe('AddstatesComponent', () => {
  let component: AddstatesComponent;
  let fixture: ComponentFixture<AddstatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddstatesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddstatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
