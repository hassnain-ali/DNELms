import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageslistComponent } from './languageslist.component';

describe('LanguageslistComponent', () => {
  let component: LanguageslistComponent;
  let fixture: ComponentFixture<LanguageslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LanguageslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LanguageslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
