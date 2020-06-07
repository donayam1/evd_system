import { TestBed } from '@angular/core/testing';

import { VoucherStatisticsService } from './voucher-statistics.service';

describe('VoucherStatisticsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VoucherStatisticsService = TestBed.get(VoucherStatisticsService);
    expect(service).toBeTruthy();
  });
});
