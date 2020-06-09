import { TestBed } from '@angular/core/testing';

import { UserBankAccountService } from './user-bank-account.service';

describe('UserBankAccountService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserBankAccountService = TestBed.get(UserBankAccountService);
    expect(service).toBeTruthy();
  });
});
