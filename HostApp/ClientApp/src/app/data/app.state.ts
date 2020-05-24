import { AccountState } from "./Account/Reducers/account.reducers";
import { AccountReducer } from "./Account/Reducers/account.reducers";
import { createSelector, createFeatureSelector } from "@ngrx/store";
// import { CommentState } from "./Comment/Reducers/comment.reducers";
import { User } from './Account/Models/user.model';
import { LanguageReducers, LanguageState } from './Language/Reducers/language.reducers';


export class AppState {
  account: AccountState;
  culture: LanguageState;
  // comments:CommentState;
}

export const AppReducers = {
  account: AccountReducer,
  culture: LanguageReducers
};

export const SelectAccountState = (state: AppState) => state.account;
export const AccountErrorMessageSelector = createSelector(
  SelectAccountState,
  (state: AccountState) => state.errorMessage
);
export const SelectIsAuthenticated = createSelector(
  SelectAccountState,
  (state: AccountState) => state.isAuthenticated
);
export const CurrentUserSelector = createSelector(
  SelectAccountState,
  (state: AccountState) => state.currentUser
);

export const SelectAllUsers = (state: AppState) => state.account.users;
export const StoreUserSelector = createSelector(
  SelectAllUsers,
  (users: User[]) => (id: string) => {
    const u0 = users.find(u => u.Id === id);
    return u0;
  }
);
export const FiterUsersNotInStoreSelector = createSelector(
  SelectAllUsers,
  (users: User[]) => (ids: string[]) => {
    const x = ids.filter((id) => {
      if (!users.find((u) => u.Id === id)) {
        return id;
      }
    });
    return x;
  }
)
