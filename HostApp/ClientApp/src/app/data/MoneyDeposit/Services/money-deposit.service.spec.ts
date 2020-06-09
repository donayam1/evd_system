import { TestBed } from '@angular/core/testing';

import { MoneyDepositService } from './money-deposit.service';

describe('MoneyDepositService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MoneyDepositService = TestBed.get(MoneyDepositService);
    expect(service).toBeTruthy();
  });
});
