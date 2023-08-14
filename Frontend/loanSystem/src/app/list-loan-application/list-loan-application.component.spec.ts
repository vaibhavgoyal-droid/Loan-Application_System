import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListLoanApplicationComponent } from './list-loan-application.component';

describe('ListLoanApplicationComponent', () => {
  let component: ListLoanApplicationComponent;
  let fixture: ComponentFixture<ListLoanApplicationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListLoanApplicationComponent]
    });
    fixture = TestBed.createComponent(ListLoanApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
