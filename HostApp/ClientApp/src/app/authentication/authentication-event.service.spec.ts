import { TestBed, inject } from '@angular/core/testing';

import { AuthenticationEventService } from './authentication-event.service';

describe('AuthenticationEventService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthenticationEventService]
    });
  });

  it('should be created', inject([AuthenticationEventService], (service: AuthenticationEventService) => {
    expect(service).toBeTruthy();
  }));
});
