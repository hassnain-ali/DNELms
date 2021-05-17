import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientDefaultComponent } from './client-default.component';

describe('ClientDefaultComponent', () => {
  let component: ClientDefaultComponent;
  let fixture: ComponentFixture<ClientDefaultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientDefaultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientDefaultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
