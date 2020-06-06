import { Users } from './user.model';

describe('User', () => {
  it('should create an instance', () => {
    expect(new Users()).toBeTruthy();
  });
});
