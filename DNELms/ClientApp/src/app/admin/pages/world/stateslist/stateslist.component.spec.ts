import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StateslistComponent } from './stateslist.component';

describe('StateslistComponent', () => {
  let component: StateslistComponent;
  let fixture: ComponentFixture<StateslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StateslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StateslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
