import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RawsqlComponent } from './rawsql.component';

describe('RawsqlComponent', () => {
  let component: RawsqlComponent;
  let fixture: ComponentFixture<RawsqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RawsqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RawsqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
