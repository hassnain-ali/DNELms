import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignmentslistComponent } from './assignmentslist.component';

describe('AssignmentslistComponent', () => {
  let component: AssignmentslistComponent;
  let fixture: ComponentFixture<AssignmentslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignmentslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignmentslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
