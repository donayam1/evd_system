import { TestBed, inject } from '@angular/core/testing';

import { LoginPageGardService } from './login-page-gard.service';

describe('LoginPageGardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LoginPageGardService]
    });
  });

  it('should be created', inject([LoginPageGardService], (service: LoginPageGardService) => {
    expect(service).toBeTruthy();
  }));
});
