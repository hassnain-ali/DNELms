import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminFooterComponent } from './admin-footer.component';

describe('FooterComponent', () => {
  let component: AdminFooterComponent;
  let fixture: ComponentFixture<AdminFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminFooterComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
