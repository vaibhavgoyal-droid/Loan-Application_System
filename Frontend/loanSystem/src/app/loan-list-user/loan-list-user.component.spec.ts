import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanListUserComponent } from './loan-list-user.component';

describe('LoanListUserComponent', () => {
  let component: LoanListUserComponent;
  let fixture: ComponentFixture<LoanListUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LoanListUserComponent]
    });
    fixture = TestBed.createComponent(LoanListUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
