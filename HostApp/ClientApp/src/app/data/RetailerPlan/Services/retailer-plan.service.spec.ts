import { TestBed } from '@angular/core/testing';

import { RetailerPlanService } from './retailer-plan.service';

describe('RetailerPlanService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RetailerPlanService = TestBed.get(RetailerPlanService);
    expect(service).toBeTruthy();
  });
});
