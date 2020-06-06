import { TestBed } from '@angular/core/testing';

import { VoucherBatchService } from './voucher-batch.service';

describe('VoucherBatchService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VoucherBatchService = TestBed.get(VoucherBatchService);
    expect(service).toBeTruthy();
  });
});
