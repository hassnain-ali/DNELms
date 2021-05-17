import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListcoursetypesComponent } from './listcoursetypes.component';

describe('ListcoursetypesComponent', () => {
  let component: ListcoursetypesComponent;
  let fixture: ComponentFixture<ListcoursetypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListcoursetypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListcoursetypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
