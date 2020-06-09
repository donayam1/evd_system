import { TestBed } from '@angular/core/testing';

import { ConfigureBankService } from './configure-bank.service';

describe('ConfigureBankService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ConfigureBankService = TestBed.get(ConfigureBankService);
    expect(service).toBeTruthy();
  });
});
