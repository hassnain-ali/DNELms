import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategorieslistComponent } from './categorieslist.component';

describe('CategorieslistComponent', () => {
  let component: CategorieslistComponent;
  let fixture: ComponentFixture<CategorieslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategorieslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategorieslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
