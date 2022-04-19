package org.charles.weilog.handler;

import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.logging.Logger;

@ControllerAdvice
public class ControllerExceptionHandler {
    private Logger logger = (Logger) LoggerFactory.getLogger(ControllerExceptionHandler.class);

    public ModelAndView handleException(HttpServletRequest request, HttpServletResponse response, Exception ex) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.addObject("exception", ex);
        modelAndView.setViewName("error/error");
        return modelAndView;
    }
}
