import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddlanguagesComponent } from './addlanguages.component';

describe('AddlanguagesComponent', () => {
  let component: AddlanguagesComponent;
  let fixture: ComponentFixture<AddlanguagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddlanguagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddlanguagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
