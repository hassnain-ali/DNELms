import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcourselevelComponent } from './addcourselevel.component';

describe('AddcourselevelComponent', () => {
  let component: AddcourselevelComponent;
  let fixture: ComponentFixture<AddcourselevelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddcourselevelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddcourselevelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
