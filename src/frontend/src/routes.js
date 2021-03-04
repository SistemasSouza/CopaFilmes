import React from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import Movies from './pages/Movies';
import Results from './pages/Results';

const Routes = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={Movies} />
            <Route exact path="/resultado" component={Results} />
        </Switch>
    </BrowserRouter>
)

export default Routes;