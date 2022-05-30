package org.charles.weilog.service;

import org.charles.weilog.domain.Term;

import java.util.List;


public interface TermService {

    boolean add(Term term);

    boolean remove(Long id);

    boolean update(Term term);

    Term query(Long id);

    List<Term> query(String tag);

    List<Term> query(int pageIndex, int pageSize);
}
