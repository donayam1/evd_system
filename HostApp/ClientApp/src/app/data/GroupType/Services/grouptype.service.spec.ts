import { TestBed } from '@angular/core/testing';

import { GrouptypeService } from './grouptype.service';

describe('GrouptypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GrouptypeService = TestBed.get(GrouptypeService);
    expect(service).toBeTruthy();
  });
});
