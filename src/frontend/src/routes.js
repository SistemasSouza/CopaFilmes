import React from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import Times from './pages/Times';
import Results from './pages/Results';

const Routes = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={Times} />
            <Route exact path="/resultado" component={Results} />
        </Switch>
    </BrowserRouter>
)

export default Routes;