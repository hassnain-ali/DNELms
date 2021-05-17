import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourselevellistComponent } from './courselevellist.component';

describe('CourselevellistComponent', () => {
  let component: CourselevellistComponent;
  let fixture: ComponentFixture<CourselevellistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourselevellistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourselevellistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
