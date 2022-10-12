package org.charles.weilog.service;

import org.charles.weilog.domain.Attachment;
import org.charles.weilog.domain.Taxonomy;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface AttachmentService {
    Attachment insert(Attachment entity);

    void remove(Long id);

    Attachment update(Attachment entity);

    Attachment query(Long id);

    List<Attachment> query(String title, int pageIndex, int pageSize);

    List<Attachment> query(int pageIndex, int pageSize);
}