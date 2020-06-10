import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUserBankDataComponent } from './edit-user-bank-data.component';

describe('EditUserBankDataComponent', () => {
  let component: EditUserBankDataComponent;
  let fixture: ComponentFixture<EditUserBankDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditUserBankDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditUserBankDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
