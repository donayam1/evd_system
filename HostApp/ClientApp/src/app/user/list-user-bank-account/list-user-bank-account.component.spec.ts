import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListUserBankAccountComponent } from './list-user-bank-account.component';

describe('ListUserBankAccountComponent', () => {
  let component: ListUserBankAccountComponent;
  let fixture: ComponentFixture<ListUserBankAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListUserBankAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListUserBankAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
